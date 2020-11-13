import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Comic } from 'src/app/models/comic.model';
import { ComicService } from '../../services/comic.service';

@Component({
  selector: 'cms-comic-detail',
  templateUrl: './comic-detail.component.html',
  styleUrls: ['./comic-detail.component.scss'],
})
export class ComicDetailComponent implements OnInit {
  comic: Comic;

  constructor(
    private route: ActivatedRoute,
    private comicService: ComicService
  ) {}

  ngOnInit(): void {
    const comicID = +this.route.snapshot.params.id;
    console.log(comicID);

    this.comicService.getComicByID(comicID).subscribe((comic) => {
      console.log(comic);

      this.comic = comic;
    });
  }
}
