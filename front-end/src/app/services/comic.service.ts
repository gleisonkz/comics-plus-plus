import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { delay } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Author } from '../models/author.model';
import { ComicImage } from '../models/comic-image.model';
import { ComicList } from '../models/comic-list.model';
import { ComicShopItemDetail } from '../models/comic-shop-item-detail.model';
import { ComicShopItem } from '../models/comic-shop-item.model';
import { Comic } from '../models/comic.model';
import { Filter } from '../models/filter.model';
import { Genre } from '../models/genre.model';

@Injectable({
  providedIn: 'root',
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
        params: comicFilter,
      })
      .pipe(delay(200));
  }

  getComicByID(comicID: number): Observable<Comic> {
    return this.http.get<Comic>(`${environment.apiURL}/comic/${comicID}`);
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
  deleteComic(comicID: number): Observable<Comic> {
    return this.http.delete<Comic>(`${environment.apiURL}/comic/${comicID}`);
  }
}
