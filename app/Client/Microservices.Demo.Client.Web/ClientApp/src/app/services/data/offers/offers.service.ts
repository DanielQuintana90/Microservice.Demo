import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { ICreateOfferCommand } from './icreate-offer-command';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OffersService {
  port = '44399';
  baseUrl = `${this.window.location.protocol}//${this.window.location.hostname}:${this.port}`;
  offersApiUrl = this.baseUrl + '/api/offers';

  constructor(
    private http: HttpClient,
    @Inject('Window') private window: Window
  ) { }

  calculatePrice(createOfferCommand: ICreateOfferCommand): Observable<any> {
    return this.http.post<any>(this.offersApiUrl, createOfferCommand)
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

