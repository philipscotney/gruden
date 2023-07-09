import { TestBed, async, inject } from '@angular/core/testing';
import { HttpClientModule } from '@angular/common/http';
import { PersonService } from './person.service';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HttpTestingController } from '@angular/common/http/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { environment } from '../environments/environment';
import { Person } from './models/person';

describe('PersonService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports: [
      HttpClientModule, HttpClientTestingModule
    ],

  }));

  afterEach(inject([HttpTestingController], (httpMock: HttpTestingController) => {
    httpMock.verify();
  }));

  it('Service Test expects service to fetch data',
    inject([HttpTestingController, PersonService],
      (httpMock: HttpTestingController, service: PersonService) => {
        let person = new Person();
        person.name = 'Dave'
        // We call the service
        service.sendName(person).subscribe(data => {

          expect(data.name).toBe('Dave');
           
        });

        // We set the expectations for the HttpClient mock
        const req = httpMock.expectOne(environment.ASPNETCORE_URLWITHPORT + '/api/person/send');
        expect(req.request.method).toEqual('POST');


        let somedata =  { id: 1, name :'Dave' };

        // Then we set the fake data to be returned by the mock
        req.flush(somedata);
      })
  );

  it('should be created', () => {
    const service: PersonService = TestBed.get(PersonService);
    expect(service).toBeTruthy();
  });
}); 
