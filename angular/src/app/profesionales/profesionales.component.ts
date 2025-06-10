import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { ProfesionalDto, ProfesionalService } from '../proxy/modules/profesionales';

@Component({
  selector: 'app-profesionales',
  standalone: false,
  templateUrl: './profesionales.component.html',
  styleUrl: './profesionales.component.scss',
  providers: [ListService],
})
export class ProfesionalesComponent implements OnInit {
  profesionales = { items: [], totalCount: 0 } as PagedResultDto<ProfesionalDto>;
  
  constructor(public readonly list: ListService, private profesionalService: ProfesionalService) {}

  ngOnInit() {
    const profesionalStreamCreator = (query) => this.profesionalService.getList(query);

    this.list.hookToQuery(profesionalStreamCreator).subscribe((response) => {
      this.profesionales = response;
    });
  }
}