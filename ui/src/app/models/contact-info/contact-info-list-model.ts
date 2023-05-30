import { BasePageableModel } from '../base/base-pageable-model';
import { ContactInfoListDto } from './contact-info-list.dto';

export interface ContactInfoListModel extends BasePageableModel {
  items: ContactInfoListDto[];
}
