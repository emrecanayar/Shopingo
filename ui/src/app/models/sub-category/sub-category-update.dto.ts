import { EntityModel } from "../base/entity-model";

export interface SubCategoryUpdateDto extends EntityModel {
    id: string;
    subCategoryName: string;
    key: string;
    categoryId: string;
  }