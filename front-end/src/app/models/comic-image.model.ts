import { SafeUrl } from '@angular/platform-browser';
export interface ComicImage {
  comicImageID?: string;
  extension: string;
  name: string;
  base64: any;
  preview?: SafeUrl;
}
