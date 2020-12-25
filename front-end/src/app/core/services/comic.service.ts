import {
  Author,
  Comic,
  ComicInventory,
  ComicList,
  Filter,
  Genre
} from '@admin/models';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ComicImage } from '@core/models/comic-image.model';
import { ComicShopItemDetail } from '@core/models/comic-shop-item-detail.model';
import { ComicShopItem } from '@core/models/comic-shop-item.model';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { delay } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ComicService {
  constructor(private http: HttpClient) {}

  getComicShopItems(): Observable<ComicShopItem[]> {
    return this.http.get<ComicShopItem[]>(
      `${environment.apiURL}/comic/shop-item`
    );
  }

  getComicShopItemDetailByID(comicID: number): Observable<ComicShopItemDetail> {
    return this.http.get<ComicShopItemDetail>(
      `${environment.apiURL}/comic/${comicID}/shop-item`
    );
  }

  getComicImageByComicID(comicID: number) {
    return this.http.get<ComicImage>(
      `${environment.apiURL}/comic/${comicID}/image`
    );
  }

  GetAuthorsByComicID(comicID: number) {
    return this.http.get<Author[]>(
      `${environment.apiURL}/comic/${comicID}/author`
    );
  }

  GetGenresByComicID(comicID: number) {
    return this.http.get<Genre[]>(
      `${environment.apiURL}/comic/${comicID}/genre`
    );
  }

  getPaginatedComics(
    comicFilter: Filter
  ): Observable<HttpResponse<ComicList[]>> {
    return this.http
      .get<ComicList[]>(`${environment.apiURL}/comic/paginator`, {
        observe: 'response',
        responseType: 'json',
        params: comicFilter
      })
      .pipe(delay(200));
  }

  getPaginatedComicsInventory(
    comicFilter: Filter
  ): Observable<HttpResponse<ComicInventory[]>> {
    return this.http
      .get<ComicInventory[]>(
        `${environment.apiURL}/comic/inventory/paginator`,
        {
          observe: 'response',
          responseType: 'json',
          params: comicFilter
        }
      )
      .pipe(delay(200));
  }

  postComic(comic: Comic): Observable<Comic> {
    return this.http.post<Comic>(`${environment.apiURL}/comic`, comic);
  }

  putComic(comicID: number, comic: Comic): Observable<Comic> {
    return this.http.put<Comic>(
      `${environment.apiURL}/comic/${comicID}`,
      comic
    );
  }

  putComicInventory(comic: ComicInventory): Observable<ComicInventory> {
    return this.http.put<ComicInventory>(
      `${environment.apiURL}/comic/${comic.comicID}/inventory`,
      comic.quantity
    );
  }

  deleteComic(comicID: number): Observable<Comic> {
    return this.http.delete<Comic>(`${environment.apiURL}/comic/${comicID}`);
  }
}
