import { Component, Input, OnInit } from '@angular/core';
import { AssetsModel } from './models/assets-navigation';

@Component({
    selector: 'tx-assets-container[assetsModel]',
    templateUrl: './assets-container.component.html',
    styleUrls: ['./assets-container.component.css']
})
export class AssetsContainerComponent implements OnInit {
    @Input()
    public assetsModel?: AssetsModel;

    public ngOnInit(): void {

    }
}