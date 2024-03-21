import { Component, Input, OnInit } from '@angular/core';
import { AssetsModel } from '../../assets-container/models/assets-navigation';

@Component({
    selector: 'tx-music-container[selectedTabIndex]',
    templateUrl: './music-container.component.html',
    styleUrls: ['./music-container.component.css']
})
export class MusicContainerComponent implements OnInit {        
    @Input()
    public selectedTabIndex: number;

    public assetsModel?: AssetsModel;    

    public ngOnInit(): void {
        this.assetsModel = {
            header: 'Music',
            description: 'Create and view your desirable songs. Customise and make it public so everyone can reuse it.',
            navigation: [
                {
                    title: 'My Music',
                    description: 'Search for your personal music',
                    link: '/app/music/own'
                },   
                {
                    title: 'Global Songs',
                    description: 'Search for all added songs',
                    link: '/app/music/global'
                },   
                {
                    title: 'Create',
                    description: 'Add and share your music',
                    link: '/app/music/add'
                },   
                {
                    title: 'Proposals',
                    description: 'Track the status of shared songs',
                    link: '/app/music/proposals'
                },   
            ]
        }
    }
}