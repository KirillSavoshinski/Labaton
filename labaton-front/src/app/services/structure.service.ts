import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { TreeItem } from '../models/tree-item';
import { BehaviorSubject, Observable } from 'rxjs'; 

@Injectable({
  providedIn: 'root',
})
export class StructureService {
  private baseUrl = environment.baseUrl;
  public selectedFolder = new BehaviorSubject(null);

  constructor(private http: HttpClient) {}

  public getStructure(path: string): Observable<TreeItem> {
    return this.http.get<TreeItem>(this.baseUrl + 'api/directories', {
      params: new HttpParams().set('path', path),
    });
  }

  public uploadJsonStructure(formData: FormData) {
    formData.append('selectedFolder', this.selectedFolder.value);
    return this.http.post(this.baseUrl + 'api/directories', formData);
  }
}
