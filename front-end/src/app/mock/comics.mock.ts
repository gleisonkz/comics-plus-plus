import { Comic } from '../models/comic.model';
export const COMICS: Comic[] = [
  {
    id: 1,
    title: 'Superman O Último Filho 3',
    author: '',
    genre: 'Ação,Aventura',
    imagePath:
      'https://excelsiorcomics.com.br/loja/wp-content/uploads/2016/08/xdc-eaglemoss-03-360x541.jpg.pagespeed.ic.B0Kj7DxdK5.webp',
    description:
      'Superman possui poderes extraordinários e é tradicionalmente descrito como "mais rápido que uma bala, mais poderoso do que uma locomotiva, capaz de saltar prédios altos em um único salto".',
    price: 30.0,
    year: 2000,
    pages: 500,
  },
  {
    id: 2,
    title: 'Batman Silêncio',
    author: '',
    genre: 'Ação',
    imagePath:
      'https://excelsiorcomics.com.br/loja/wp-content/uploads/2016/08/xdc-eaglemoss-02-360x538.jpg.pagespeed.ic.xry6bFHav-.webp',
    description:
      'A identidade secreta de Batman é Bruce Wayne, um bilionário americano, playboy, magnata de negócios, filantropo e dono da corporação Wayne Enterprises.',
    price: 120.0,
    year: 2012,
    pages: 700,
  },
  {
    id: 3,
    title: 'LJA Ano Um',
    author: '',
    genre: 'Ciência,Ficção',
    imagePath:
      'https://excelsiorcomics.com.br/loja/wp-content/uploads/2017/04/xeaglemoss-10-360x541.jpg.pagespeed.ic.OpCkzNGTpS.webp',
    description:
      'LJA: Ano Um é uma história que olha para o passado da DC, para os diversos grupos heroicos que já passaram pela editora e honra o que eles deixaram para as equipes futuras, dando a oportunidade de lutarem ao lado dos recém-chegados e de perceberem que estão sendo substituídos por gente muito boa.',
    price: 90.0,
    year: 2015,
    pages: 180,
  },
];
