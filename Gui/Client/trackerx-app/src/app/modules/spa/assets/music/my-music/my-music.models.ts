export class MyMusicViewModel {
    public musicProfileId!: number;
    public description!: string;
    public album?: string | null;    
    public author?: string | null;    
    public type!: string;
    public isPublished: boolean;
    public assetAddedDate: Date;        
}

export class MyMusicSearchArguments {
    public descriptionPattern: string;
    public type: string;
    public includePublished?: boolean | null;
}