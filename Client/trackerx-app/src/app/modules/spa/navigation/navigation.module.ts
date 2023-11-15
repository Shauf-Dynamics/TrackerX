import { NgModule } from "@angular/core";
import { SideBarComponent } from "./side-bar/side-bar.component";
import { HeaderComponent } from "./header/header.component";
import { NavigationContainerComponent } from "./navigation-container/navigation-container.component";
import { AuthService } from "src/app/providers/auth/auth.service";

@NgModule({
    declarations: [
        HeaderComponent,
        SideBarComponent,
        NavigationContainerComponent
    ],
    providers: [
        AuthService
    ],
    exports: [
        NavigationContainerComponent
    ]
  })
  export class NavigationModule { }
  