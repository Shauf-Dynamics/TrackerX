import { AssetsNavigation } from "./assets-model";

export class AssetsModel {
    public header?: string;
    public description?: string;
    public navigation: AssetsNavigation[] = [];
}