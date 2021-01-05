import { ComicInventory } from '@admin/models';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GenericBaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class ComicInventoryService extends GenericBaseService<ComicInventory> {
  constructor(protected http: HttpClient) {
    super(http);
    this.endpoint = '/comic/inventory';
  }

  getPaginatedComicsInventory = this.getPaginatedEntities;
  putComicInventory = this.putEntity;
}
