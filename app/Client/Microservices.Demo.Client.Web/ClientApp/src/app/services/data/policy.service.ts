import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IPolicy } from '../../models/ipolicy';
import { map, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PolicyService {
  port = '44399';
  baseUrl = `${this.window.location.protocol}//${this.window.location.hostname}:${this.port}`;
  reportsApiUrl = this.baseUrl + '/api/reports';

  constructor(
    private http: HttpClient,
    @Inject('Window') private window: Window
  ) { }

  getPolicies(): Observable<IPolicy[]> {
    return this.http.get<IPolicy[]>(this.reportsApiUrl + '/getpolicies')
      .pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    console.error('server error:', error);
    if (error.error instanceof Error) {
      const errMessage = error.error.message;
      return Observable.throw(errMessage);
    }
    return Observable.throw(error || 'server error');
  }

}
