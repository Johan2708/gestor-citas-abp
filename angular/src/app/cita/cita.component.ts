import { ListService, PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms'; // add this
import { CitaDto } from '../proxy/modules/citas-dto';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { CitaService } from '../proxy/modules/citas';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { ClienteService } from '../proxy/modules/clientes';


@Component({
  selector: 'app-cita',
  // eslint-disable-next-line @angular-eslint/prefer-standalone
  standalone: false,
  templateUrl: './cita.component.html',
  styleUrls: ['./cita.component.scss'],
  providers: [ListService,{ provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],
})
export class CitaComponent implements OnInit {
  cita: PagedResultDto<CitaDto> = { items: [], totalCount: 0 };
  selectedCita: CitaDto = {} as CitaDto;
  form!: FormGroup;
  isModalOpen= false;
  listOfClientes: any[] = [];

  constructor(
    public readonly list: ListService,
    private citaService: CitaService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService,
    private clienteService: ClienteService
  ) {}


  ngOnInit() {
    const bookStreamCreator = (query) => this.citaService.getList(query);

    this.list.hookToQuery(bookStreamCreator).subscribe((response) => {
      this.cita = response;
    });

    this.clienteService.getList(new PagedAndSortedResultRequestDto()).subscribe((clientes) => {
      this.listOfClientes = clientes.items.map(cliente => ({
        label: cliente.nombre + ' ' + cliente.apellido,
        value: cliente.id
      }));
    });
  }

  createCita() {
    this.selectedCita = {} as CitaDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  editCita(id: number) {
    // Here you should fetch the cita by id, for now just reset
    this.selectedCita = {} as CitaDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  delete(id: string) {
    this.confirmation.warn('¿Estás seguro de eliminar esta cita?', 'Confirmar').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.citaService.delete(id).subscribe(() => this.list.get());
      }
    });
  }

  buildForm() {
    this.form = this.fb.group({
      clienteId: [this.selectedCita?.clienteId ?? null, Validators.required],
      profesionalId: [this.selectedCita?.profesionalId ?? null, Validators.required],
      fechaCita: [this.selectedCita?.fechaCita ?? null, Validators.required],
      motivo: [this.selectedCita?.motivo ?? null, Validators.required],
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    const request = this.selectedCita && this.selectedCita.id
      ? this.citaService.update(this.selectedCita.id, this.form.value)
      : this.citaService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }
}
