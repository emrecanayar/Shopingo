import { BasePageableModel } from "../base/base-pageable-model";
import { CountryListDto } from "./country-list-dto";


export interface CountryListModel extends BasePageableModel {
    items: CountryListDto[];
}