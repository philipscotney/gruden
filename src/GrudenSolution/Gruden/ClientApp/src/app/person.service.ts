import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs'; 
import { environment } from '../environments/environment';
import { Person } from './models/person';


@Injectable({
    providedIn: 'root'
})
export class PersonService {
   
    constructor(private http: HttpClient) {
    }

    sendName(person: Person): Observable<any> {

      const httpOptions = {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        })
      };
         let url = environment.ASPNETCORE_URLWITHPORT + '/api/person/send'; 

       const body = JSON.stringify(person);
   
      return this.http.post(url, body, httpOptions);
    }
}
