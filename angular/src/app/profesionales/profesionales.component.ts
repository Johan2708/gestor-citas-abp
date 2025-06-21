import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { ProfesionalDto, ProfesionalService } from '../proxy/modules/profesionales';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-profesionales',
  // eslint-disable-next-line @angular-eslint/prefer-standalone
  standalone: false,
  templateUrl: './profesionales.component.html',
  styleUrl: './profesionales.component.scss',
  providers: [
    ListService,
    { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }
  ],
})
export class ProfesionalesComponent implements OnInit {
  profesionales = { items: [], totalCount: 0 } as PagedResultDto<ProfesionalDto>;
  selectedProfesional = {} as ProfesionalDto;
  form: FormGroup;
  isModalOpen = false;

  constructor(
    public readonly list: ListService,
    private profesionalService: ProfesionalService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService
  ) {}

  ngOnInit() {
    const profesionalStreamCreator = (query) => this.profesionalService.getList(query);
    this.list.hookToQuery(profesionalStreamCreator).subscribe((response) => {
      this.profesionales = response;
    });
  }

  createProfesional() {
    this.selectedProfesional = {} as ProfesionalDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  editProfesional(id: string) {
    this.profesionalService.get(id).subscribe((profesional) => {
      this.selectedProfesional = profesional;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  delete(id: string) {
    this.confirmation.warn('¿Estás seguro de eliminar este profesional?', 'Confirmar').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.profesionalService.delete(id).subscribe(() => this.list.get());
      }
    });
  }

  buildForm() {
    this.form = this.fb.group({
      nombre: [this.selectedProfesional.nombre || '', Validators.required],
      especializacion: [this.selectedProfesional.especializacion || null, Validators.required],
      direccion: [this.selectedProfesional.direccion || null, Validators.required],
      telefono: [
        this.selectedProfesional.telefono || null,
        [
          Validators.required,
          Validators.pattern('^[0-9]+$'),
          Validators.minLength(7),
          Validators.maxLength(15)
        ]
      ],
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    const request = this.selectedProfesional.id
      ? this.profesionalService.update(this.selectedProfesional.id, this.form.value)
      : this.profesionalService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }
}