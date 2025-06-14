import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { ClienteDto, ClienteService } from '../proxy/modules/clientes';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-cliente',
  standalone: false,
  templateUrl: './cliente.component.html',
  styleUrl: './cliente.component.scss',
  providers: [
    ListService,
  { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],
})
export class ClienteComponent implements OnInit {
  client = { items: [], totalCount: 0 } as PagedResultDto<ClienteDto>;
  selectedClient = {} as ClienteDto;
  form: FormGroup;
  isModalOpen = false;

  constructor(
    public readonly list: ListService, 
    private clienteService: ClienteService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService
  ) {}

  ngOnInit() {
    const bookStreamCreator = (query) => this.clienteService.getList(query);

    this.list.hookToQuery(bookStreamCreator).subscribe((response) => {
      this.client = response;
    });
  }

  createClient() {
    this.selectedClient = {} as ClienteDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  editClient(id: string) {
    this.clienteService.get(id).subscribe((client) => {
      this.selectedClient = client;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.clienteService.delete(id).subscribe(() => this.list.get());
      }
    });
  }

  buildForm() {
    this.form = this.fb.group({
      nombre: [this.selectedClient.nombre || '', Validators.required],
      apellido: [this.selectedClient.apellido || null, Validators.required],
      email: [this.selectedClient.email || null, [Validators.required, Validators.email]],
      telefono: [
      this.selectedClient.telefono || null,
        [
          Validators.required,
          Validators.pattern('^[0-9]+$'),
          Validators.minLength(7), 
          Validators.maxLength(15)
        ]
      ],
      direccion: [this.selectedClient.direccion || null, Validators.required],
      fechaNacimiento: [
      this.selectedClient.fechaNacimiento ? new Date(this.selectedClient.fechaNacimiento) : null
      ],
    });
  }

  // add save method
  save() {
    if (this.form.invalid) {
      return;
    }

    const request = this.selectedClient.id
      ? this.clienteService.update(this.selectedClient.id, this.form.value)
      : this.clienteService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }
}