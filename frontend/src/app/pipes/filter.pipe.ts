import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filter',
})
export class FilterPipe implements PipeTransform {
  transform(items: any[], filter: { [key: string]: any }): any[] {
    if (!items || !filter) {
      return items;
    }
    return items.filter((item) => {
      return Object.keys(filter).every((key) => {
        return item[key].toLowerCase().includes(filter[key].toLowerCase());
      });
    });
  }
}
