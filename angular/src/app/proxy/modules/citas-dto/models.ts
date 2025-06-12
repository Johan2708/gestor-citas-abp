import type { AuditedEntityDto } from '@abp/ng.core';

export interface CitaDto extends AuditedEntityDto<string> {
  id?: string;
  clienteId?: string;
  profesionalId?: string;
  fechaCita?: string;
  motivo?: string;
}

export interface CreateUpdateCitaDto {
  clienteId: string;
  profesionalId: string;
  fechaCita: string;
  motivo: string;
}
