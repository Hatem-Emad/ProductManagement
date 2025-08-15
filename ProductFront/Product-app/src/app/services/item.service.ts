import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

export interface Item {
  id: number;
  name: string;
  description: string;
  categoryId: number;
}

@Injectable({
  providedIn: 'root'
})
export class ItemService {
  private apiUrl = `${environment.apiBaseUrl}/Item`;

  constructor(private http: HttpClient) { }

  getItems(): Observable<Item[]> {
    return this.http.get<Item[]>(this.apiUrl);
  }

  getItemById(id: number): Observable<Item> {
    return this.http.get<Item>(`${this.apiUrl}/${id}`);
  }

  createItem(item: Omit<Item, 'id'>): Observable<Item> {
    return this.http.post<Item>(this.apiUrl, item);
  }

  updateItem(item: Item): Observable<Item> {
    return this.http.put<Item>(this.apiUrl, item);
  }

  patchItem(item: Partial<Item>): Observable<Item> {
    return this.http.patch<Item>(this.apiUrl, item);
  }

  deleteItem(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
