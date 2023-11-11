import { NgModule } from "@angular/core";
import { SideBarComponent } from "./side-bar/side-bar.component";
import { HeaderComponent } from "./header/header.component";
import { NavigationContainerComponent } from "./navigation-container/navigation-container.component";

@NgModule({
    declarations: [
        HeaderComponent,
        SideBarComponent,
        NavigationContainerComponent
    ],
    providers: [],
    exports: [
        NavigationContainerComponent
    ]
  })
  export class NavigationModule { }
  