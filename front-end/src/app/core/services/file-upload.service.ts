import { Injectable } from '@angular/core';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { ComicImage } from '@core/models/comic-image.model';
import { FileInput } from 'ngx-material-file-input';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FileUploadService {
  constructor(private domSanitizer: DomSanitizer) {}

  readFileAsBinaryString(file: File): Observable<ComicImage> {
    const temporaryFileReader = new FileReader();
    const [fileName, fileExtension] = file.name.split('.');

    return new Observable<ComicImage>((publisher) => {
      temporaryFileReader.onload = () => {
        const binaryString = temporaryFileReader.result as string;
        const base64 = btoa(binaryString);
        const comicImage: ComicImage = {
          base64: base64,
          extension: fileExtension,
          name: fileName
        };
        publisher.next(comicImage);
      };

      temporaryFileReader.onerror = () => {
        temporaryFileReader.abort();
        publisher.error('Problem parsing with file.');
      };

      temporaryFileReader.readAsBinaryString(file);
    });
  }

  fileInputFromBinaryString(image: ComicImage) {
    const base64toBlob = (base64, type = 'application/octet-stream') =>
      fetch(`data:${type};base64,${base64}`).then((res) => res.blob());

    base64toBlob(image.base64, 'image').then((c) => {
      const file = new File([c], `${image.name}.${image.extension}`, {
        type: `image/${image.extension}`
      });

      return new FileInput([file]);
    });
  }

  loadImagePreview(extension: string, base64: string): SafeUrl {
    return this.domSanitizer.bypassSecurityTrustUrl(
      `data:image/${extension};base64,` + base64
    );
  }
}
