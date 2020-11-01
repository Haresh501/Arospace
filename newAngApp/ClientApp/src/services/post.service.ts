import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders,   } from '@angular/common/http';
import { environment } from '../environments/environment';

@Injectable()
export class AdminService {

    localURL: string = environment.URL;

    headers: HttpHeaders; 

      

  constructor(private _http: HttpClient) {

   
    this.headers = new HttpHeaders()
      .set('content-type', 'application/json')
      .set('Access-Control-Allow-Origin', '*');
        
    }

  //get method - select 
  GetCategories() {
    return this._http.get(this.localURL + 'Admin/GetCategories', { 'headers': this.headers });
  }

  AddCategories(categories:any) {
    return this._http.post(this.localURL + 'Admin/AddCategories', categories, { 'headers': this.headers });
  }
  
}

