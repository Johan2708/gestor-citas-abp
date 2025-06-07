import type { AuditedEntityDto } from '@abp/ng.core';

export interface ClienteDto extends AuditedEntityDto<string> {
  nombre?: string;
  apellido?: string;
  telefono?: string;
  email?: string;
  direccion?: string;
  fechaNacimiento?: string;
}

export interface CreateUpdateClienteDto {
  nombre: string;
  apellido: string;
  telefono: string;
  email: string;
  direccion: string;
  fechaNacimiento?: string;
}
