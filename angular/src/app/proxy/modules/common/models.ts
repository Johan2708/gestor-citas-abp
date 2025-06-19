import type { PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CreateResponse {
  id?: string;
}

export interface PagedAndSortedIncludeSearchInputDto extends PagedAndSortedResultRequestDto {
  generalSearch?: string;
  includes: string[];
}
