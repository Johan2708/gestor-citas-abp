import type { ClienteDto, CreateUpdateClienteDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { CreateResponse, PagedAndSortedIncludeSearchInputDto } from '../common/models';

@Injectable({
  providedIn: 'root',
})
export class ClienteService {
  apiName = 'Default';
  

  create = (input: CreateUpdateClienteDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ClienteDto>({
      method: 'POST',
      url: '/api/app/cliente',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  createNew = (input: CreateUpdateClienteDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CreateResponse>({
      method: 'POST',
      url: '/api/app/cliente/new',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/cliente/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ClienteDto>({
      method: 'GET',
      url: `/api/app/cliente/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedIncludeSearchInputDto | PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ClienteDto>>({
      method: 'GET',
      url: '/api/app/cliente',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateUpdateClienteDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ClienteDto>({
      method: 'PUT',
      url: `/api/app/cliente/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
