import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { ICreatePolicyCommand } from './icreate-policy-command';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ICreatePolicyResult } from './icreate-policy-result';

@Injectable({
  providedIn: 'root'
})
export class PoliciesService {
  port = '44399';
  baseUrl = `${this.window.location.protocol}//${this.window.location.hostname}:${this.port}`;
  policiesApiUrl = this.baseUrl + '/api/policies';

  constructor(
    private http: HttpClient,
    @Inject('Window') private window: Window
  ) { }

  CreatePolicy(createPolicyCommand: ICreatePolicyCommand): Observable<ICreatePolicyResult> {
    return this.http.post<ICreatePolicyResult>(this.policiesApiUrl, createPolicyCommand)
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
