import {
  Component,
  Input,
  ViewChild,
  OnInit,
  OnDestroy,
  ElementRef,
  Injectable,
  Output,
  EventEmitter,
  Inject
} from '@angular/core';
import { FormGroup, FormBuilder, ReactiveFormsModule, FormControl } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'fi-sidebar',
  styleUrls: ['./sidebar.component.scss'],
  templateUrl: './sidebar.component.html',
})
@Injectable()
export class SideBarComponent implements OnInit, OnDestroy {


  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string) {  //private store: Store<fromLayout.State>
    this.focForm = new FormGroup({
      searchField: new FormControl(),
      categoryField: new FormControl(),
      sizeField: new FormControl()
    });
  }

  //isLoading$: Observable<boolean> = this.store.pipe(
  //  select(fromLayout.getIsSearchLoading)
  //);

  public focForm: FormGroup;

  title = 'Search in our Art Directory';



  searchForm: string = "";
  sizeForm: string = "";
  categoryForm: string = "";

  public results: ArtDirectory[];
  public searchTerms: ISearchTerms;
  public searchProgress: boolean = true;
  public pageId: number = 1;

  private searchTextForHistory: string;

  categoryOptions = [
    { name: "Any", value: 0},
    { name: "Paint", value: 1 },
    { name: "Canvas", value: 2 }
  ]
  categorySelected = 0;

  sizeOptions = [
    { name: "Any", value: "" },
    { name: "Small", value: "S" },
    { name: "Medium", value: "M" },
    { name: "Large", value: "L" }
  ]
  sizeSelected = "";

  searchSelected = "";

  ngOnInit() {

  };


  SearchArt(): void {

    this.results = [];

    this.searchTextForHistory = this.searchSelected;

    this.searchTerms = {
      name: this.searchSelected,
      category: Number(this.categorySelected),
      priceMin: 0,
      priceMax: 450,
      size: this.sizeSelected,
      original: '',
      signed: null,
      page: 1
    };

    var body = JSON.stringify(this.searchTerms);
    var headers = { 'content-type': 'application/json' };

    this.http.post<APIResponse>(this.baseUrl + 'api/Inventory', body, { 'headers': headers }).subscribe(result => {
      this.results = result.artDirectory;
      this.searchProgress = false;
    }, error => console.error(error));

    //alert('category selected ' + this.categorySelected + " size selected: " + this.sizeSelected + " text :" + this.searchSelected);
};

  ngOnDestroy() {
    //this.focForm.valueChanges.unsubscribe();
  };
}

interface APIResponse {
  artDirectory: ArtDirectory[],
  page: number,
  totalPages: number
}

interface ArtDirectory {
  Id: number;
  Name: string;
  Description: string;
  Category: number;
  Visible: boolean;
  Price: number;
  Size: string;
  Original: string;
  Signed: boolean;
  Code: string;
}

export interface ISearchTerms {
  name: string;
  category: number;
  priceMin: number;
  priceMax: number;
  size: string;
  original: string;
  signed: boolean;
  page: number;
}
