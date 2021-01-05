import { Author, Comic, ComicList, Filter, Genre } from '@admin/models';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ComicImage } from '@core/models/comic-image.model';
import { ComicShopItemDetail } from '@core/models/comic-shop-item-detail.model';
import { ComicShopItem } from '@core/models/comic-shop-item.model';
import { BaseService } from '@core/services';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ComicService extends BaseService {
  constructor(protected http: HttpClient) {
    super();
    this.endpoint = '/comic';
  }

  getComicShopItems(): Observable<ComicShopItem[]> {
    return this.http.get<ComicShopItem[]>(`${this.endpoint}/shop-item`);
  }

  getComicShopItemDetailByID(comicID: number): Observable<ComicShopItemDetail> {
    return this.http.get<ComicShopItemDetail>(
      `${this.endpoint}/${comicID}/shop-item`
    );
  }

  getComicImageByComicID(comicID: number) {
    return this.http.get<ComicImage>(`${this.endpoint}/${comicID}/image`);
  }

  GetAuthorsByComicID(comicID: number) {
    return this.http.get<Author[]>(`${this.endpoint}/${comicID}/author`);
  }

  GetGenresByComicID(comicID: number) {
    return this.http.get<Genre[]>(`${this.endpoint}/${comicID}/genre`);
  }

  getPaginatedComics(
    comicFilter: Filter
  ): Observable<HttpResponse<ComicList[]>> {
    return this.getPaginatedData(this.http, comicFilter);
  }

  postComic(comic: Comic): Observable<Comic> {
    return this.http.post<Comic>(`${this.endpoint}`, comic);
  }

  putComic(comicID: number, comic: Comic): Observable<Comic> {
    return this.http.put<Comic>(`${this.endpoint}/${comicID}`, comic);
  }

  deleteComic(comicID: number): Observable<Comic> {
    return this.http.delete<Comic>(`${this.endpoint}/${comicID}`);
  }
}
