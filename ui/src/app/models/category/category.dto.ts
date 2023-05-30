import { SubCategoryDto } from "../sub-category/sub-category.dto";

export interface CategoryDto {
    id: string;
    categoryName: string;
    key: string;
    subCategories: SubCategoryDto[];
  }
  