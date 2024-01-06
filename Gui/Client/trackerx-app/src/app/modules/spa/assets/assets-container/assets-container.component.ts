import { Component, Input, OnInit } from '@angular/core';
import { AssetsModel } from './models/assets-navigation';

@Component({
    selector: 'tx-assets-container[assetsModel][selectedTabIndex]',
    templateUrl: './assets-container.component.html',
    styleUrls: ['./assets-container.component.css']
})
export class AssetsContainerComponent {
    @Input()
    public assetsModel?: AssetsModel;

    @Input()
    public selectedTabIndex: number;
}