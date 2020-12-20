import { Component, Output, EventEmitter, Input, OnChanges } from '@angular/core';

@Component({
  selector: 'app-history-search',
  templateUrl: './app-history-search.component.html'//,
  //styleUrls: ['./app-history-search.component.css']
})
export class AppHistorySearchComponent implements OnChanges {
  @Input() lastSearch: string;
  @Input() lastCategory: string;
  @Input() lastSize: string;

  public searchHistory: Array<{ search: string, category: string, size: string }> = [];

  constructor() { }

  message: string;

  ngOnChanges(changes: any) {
    //this.message = changes.lastSearch.currentValue;
    if (changes.lastSearch.currentValue !== undefined) {
      this.searchHistory.push({ search: changes.lastSearch.currentValue, category: this.lastCategory, size: this.lastSize });
    }
  }

}
