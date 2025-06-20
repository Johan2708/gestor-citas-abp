
export interface ProfesionalDto {
  id?: string;
  nombre?: string;
  especializacion?: string;
  direccion?: string;
  telefono?: string;
}

export interface CreateUpdateProfesionalDto {
  nombre?: string;
  especializacion?: string;
  direccion?: string;
  telefono?: string;
}
