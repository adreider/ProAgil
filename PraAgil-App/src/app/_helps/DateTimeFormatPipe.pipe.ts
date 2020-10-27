import { DatePipe } from '@angular/common';
import { Pipe, PipeTransform } from '@angular/core';
import { constants } from 'buffer';
import { Constants } from '../util/constants';

@Pipe({
  name: 'DateTimeFormatPipe'
})
export class DateTimeFormatPipePipe extends DatePipe implements PipeTransform {

  transform(value: any, args?: any): any {
    return super.transform(value, Constants.DATE_TIME_FMT);
  }

}
