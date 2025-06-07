import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { ClienteDto, ClienteService } from '../proxy/modules/clientes';

@Component({
  selector: 'app-cliente',
  standalone: false,
  templateUrl: './cliente.component.html',
  styleUrl: './cliente.component.scss',
  providers: [ListService],
})
export class ClienteComponent implements OnInit {
  client = { items: [], totalCount: 0 } as PagedResultDto<ClienteDto>;
  
  constructor(public readonly list: ListService, private bookService: ClienteService) {}

  ngOnInit() {
    const bookStreamCreator = (query) => this.bookService.getList(query);

    this.list.hookToQuery(bookStreamCreator).subscribe((response) => {
      this.client = response;
    });
  }
}