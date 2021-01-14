interface ComicInventory extends ComicInventoryResource {
  comicID: number;
}

interface ComicInventoryResource {
  title: string;
  quantity: number;
}

interface ComicInventoryListItem {
  comicID: number;
  title: string;
  quantity: number;
}

export { ComicInventory, ComicInventoryListItem, ComicInventoryResource };
