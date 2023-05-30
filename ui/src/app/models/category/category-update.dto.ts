import { EntityModel } from './../base/entity-model';

export interface CategoryUpdateDto extends EntityModel {
  id: string;
  categoryName: string;
  key: string;
}
