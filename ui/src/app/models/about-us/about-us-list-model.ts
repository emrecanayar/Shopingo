import { BasePageableModel } from '../base/base-pageable-model';
import { AboutUsListDto } from './about-us-list-dto';

export interface AboutUsListModel extends BasePageableModel {
  items: AboutUsListDto[];
}
