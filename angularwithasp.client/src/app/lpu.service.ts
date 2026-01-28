import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LPUService {
  private apiUrl = 'http://localhost:5170/api/lpu';

  constructor(private http: HttpClient) { }

  getLpus(): Observable<any> {
    return this.http.get(`${this.apiUrl}/getLpus`);
  }

  getKsForLpu(kodLPU: number): Observable<any> {
    return this.http.get(`${this.apiUrl}/getKS/${kodLPU}`);
  }
}
