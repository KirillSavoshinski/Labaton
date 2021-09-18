import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { TreeItem } from '../models/tree-item';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StructureService {
  baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) { }

  public getStructure(path: string): Observable<TreeItem> {
    return this.http.get<TreeItem>(this.baseUrl + 'api/directories', { params: new HttpParams().set('path', path) });
  }
}
