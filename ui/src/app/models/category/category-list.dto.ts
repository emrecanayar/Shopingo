import { SubCategoryDto } from "../sub-category/sub-category.dto";

export interface CategoryListDto {
    id: string;
    categoryName: string;
    key: string;
    subCategories: SubCategoryDto[];
  }