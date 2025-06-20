import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms'; // add this
import { CitaDto } from '../proxy/modules/citas-dto';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { CitaService } from '../proxy/modules/citas';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { ClienteService } from '../proxy/modules/clientes';
import { PagedAndSortedResultRequestDto } from '@abp/ng.core';
import { ProfesionalService } from '../proxy/modules/profesionales';
import type { PagedAndSortedIncludeSearchInputDto } from '../proxy/modules/common/models';


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
  listOfProfessionals: any[] = [];

  constructor(
    public readonly list: ListService,
    private citaService: CitaService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService,
    private clienteService: ClienteService,
    private profesionalService: ProfesionalService // Assuming you have a service for professionals, adjust as needed
  ) {}


  ngOnInit() {
    const bookStreamCreator = (query: PagedAndSortedIncludeSearchInputDto) => {
      const queryWithIncludes = { ...query, includes: ['cliente', 'profesional'] };
      return this.citaService.getList(queryWithIncludes);

      
    };

    this.list.hookToQuery(bookStreamCreator).subscribe((response) => {
      this.cita = response;
    });

    this.clienteService.getList(new PagedAndSortedResultRequestDto()).subscribe((clientes) => {
      this.listOfClientes = clientes.items.map(cliente => ({
        label: cliente.nombre + ' ' + cliente.apellido,
        value: cliente.id
      }));
    });
//listOfProfessionals
    this.profesionalService.getList(new PagedAndSortedResultRequestDto()).subscribe((profesionales) => {
      this.listOfProfessionals = profesionales.items.map(profesional => ({
        label: profesional.nombre + ' ' + profesional.especializacion,
        value: profesional.id
      }));
    });
  }
  

  createCita() {
    this.selectedCita = {} as CitaDto; //carga en blanco OK
    this.buildForm();
    this.isModalOpen = true;
  }

  editCita(cita: CitaDto) {
    this.selectedCita = cita; // Cargar con informacion
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
      fechaCita: [this.selectedCita?.fechaCita ? new Date(this.selectedCita?.fechaCita): null, Validators.required],
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
