import type { AuditedEntityDto } from '@abp/ng.core';
import type { ClienteDto } from '../clientes/models';
import type { ProfesionalDto } from '../profesionales/models';

export interface CitaDto extends AuditedEntityDto<string> {
  id?: string;
  clienteId?: string;
  cliente: ClienteDto;
  empleadoId?: string;
  profesional: ProfesionalDto;
  fechaCita?: string;
  motivo?: string;
}

export interface CreateUpdateCitaDto {
  clienteId: string;
  profesionalId: string;
  fechaCita: string;
  motivo: string;
}
