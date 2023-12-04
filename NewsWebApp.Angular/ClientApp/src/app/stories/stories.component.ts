import { Component, Inject, ViewChild } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { MatTableDataSource } from '@angular/material';
import { MatPaginator, PageEvent } from '@angular/material';
import { Story } from './story';

@Component({
    selector: 'app-stories',
    templateUrl: './stories.component.html',
    styleUrls: ['./stories.component.css']
})
/** stories component*/
export class StoriesComponent {

  stories: MatTableDataSource<Story>;
  public displayedColumns: string[] = ['id', 'title', 'url'];
  public filter = "";
  public loading = false;

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private _baseUrl: string) {
  }

  getData(event: PageEvent) {
    var url = this._baseUrl + 'api/Story';
    var params = new HttpParams()
      .set("pageIndex", event.pageIndex.toString())
      .set("pageSize", event.pageSize.toString());

    this.callService(url, params);
  }

  getFilteredData(filter: string) {
    var url = this._baseUrl + 'api/Story/GetFilteredStories';
    var params = new HttpParams()
      .set("filter", filter);

    this.callService(url, params);
  }

  callService(url: string, params: HttpParams) {
    this.loading = true;
    this.http.get<any>(url, { params })
      .subscribe(result => {
        this.stories = new MatTableDataSource(result.data);
        this.paginator.length = result.count;
        this.paginator.pageIndex = result.pageIndex;
        this.paginator.pageSize = result.pageSize;
        this.loading = false;
      }, error => console.error(error));
 }

  ngOnInit() {
    this.getFilteredData('');
  }

  ngAfterViewInit() {
    if (this.stories) {
      this.stories.paginator = this.paginator;
    }
  }

  applyFilter(filterValue: string) {
    filterValue = filterValue.toLowerCase(); // Datasource defaults to lowercase matches
    this.filter = filterValue;
    this.getFilteredData(this.filter);
  }
}
