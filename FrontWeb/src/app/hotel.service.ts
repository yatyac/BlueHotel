import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders} from '@angular/common/http';
import { Observable,of } from 'rxjs';
import { Hotel } from './model/hotel';

@Injectable({
  providedIn: 'root'
})
export class HotelService {
  private apiUrl ='https://localhost:44374/api/hotels';

  constructor(
    private http: HttpClient) { }
    getHotels() : Observable<Hotel[]>{
    return this.http.get<Hotel[]>(this.apiUrl)
    }
    getHotel(hotetId: number) : Observable<Hotel>{
      return this.http.get<Hotel>(`${this.apiUrl}/${hotetId}`);

    }
}
