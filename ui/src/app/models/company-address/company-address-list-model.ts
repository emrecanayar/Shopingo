import { BasePageableModel } from '../base/base-pageable-model';
import { CompanyAddressListDto } from './company-address-list-dto';

export interface CompanyAddressListModel extends BasePageableModel {
    items: CompanyAddressListDto[];

}
