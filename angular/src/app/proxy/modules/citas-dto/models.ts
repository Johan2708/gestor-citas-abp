import type { AuditedEntityDto } from '@abp/ng.core';
import type { ClienteDto } from '../clientes/models';

export interface CitaDto extends AuditedEntityDto<string> {
  clienteId?: string;
  profesionalId?: string;
  fechaCita?: string;
  motivo?: string;
  cliente: ClienteDto;
}

export interface CreateUpdateCitaDto {
  clienteId: string;
  profesionalId: string;
  fechaCita: string;
  motivo: string;
}
