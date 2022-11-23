import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'relationship'
})
export class RelationshipPipe implements PipeTransform {
  transform(value: unknown, ...args: unknown[]): string {
    if (value === 0) return 'Friend';
    return '';
  }
}

@Pipe({
  name: 'buttonRelationship'
})
export class ButtonRelationshipPipe implements PipeTransform {
  transform(value: any, ...args: any[]) {
    if (value === 0) return 'Message';
    if (value === 1) return 'View profile';
    return 'Add friend';
  }
}
