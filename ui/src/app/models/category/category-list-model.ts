import { BasePageableModel } from '../base/base-pageable-model';
import { CategoryListDto } from './category-list.dto';

export interface CategoryListModel extends BasePageableModel {
  items: CategoryListDto[];
}
