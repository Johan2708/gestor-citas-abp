import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component ,OnInit} from '@angular/core';
import { CitaDto } from '../proxy/citas-dto/models'; // <-- Use the correct path for CitaDto
import { CitaService } from '../proxy/citas'; // <-- Use the correct service for CitaDto

@Component({
  selector: 'app-cita',
  standalone: false,
  templateUrl: './cita.component.html',
  styleUrl: './cita.component.scss',
  providers: [ListService],
})
export class CitaComponent implements OnInit {
  cita = { items: [], totalCount: 0 } as PagedResultDto<CitaDto>;
  constructor(public readonly list: ListService, private citaService: CitaService) {}
  ngOnInit() {
    const citaStreamCreator = (query) => this.citaService.getList(query);
    this.list.hookToQuery(citaStreamCreator).subscribe((response) => {
      this.cita = response;

    });
  }
}

