import { NgModule } from "@angular/core";
import { AutocompleteComponent } from "./autocomplete/autocomplete.component";

@NgModule({
    imports: [AutocompleteComponent],
    exports: [AutocompleteComponent]
  })
  export class SharedModule {}