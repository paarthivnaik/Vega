import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/map';
import { Response } from '_debugger';
@Injectable()
export class VehicleService {

  constructor(private http: HttpClient) { }

  getMakes() {

    return this.http.get('/api/makes');
  }

  getFeatures() {
    return this.http.get('/api/features');
}
